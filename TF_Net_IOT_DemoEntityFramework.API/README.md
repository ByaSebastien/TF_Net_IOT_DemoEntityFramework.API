# 📂 Entity Framework Core - Approche Code First

## 📌 Objectif

Utiliser Entity Framework Core en **Code First** pour :

* Définir les entités C#.
* Configurer la base via le **Fluent API**.
* Gérer la base de données avec les **migrations**.

---

## 🧱 Étape 1 - Initialisation du projet

Installer les packages NuGet :

```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
```
---

## 📦 Étape 2 - Définir les entités

Chaque entité représente une table de la base de données.

```csharp
public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; }

    // Navigation Property
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }

    // Foreign Key
    public int StudentId { get; set; }

    // Navigation Property
    public Student Student { get; set; }
}
```

---

## 💠 Étape 3 - Configuration avec Fluent API

Dans des class de config, on configure les relations, contraintes, noms de colonnes, longueurs, etc.

```csharp
public class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FullName)
              .IsRequired()
              .HasMaxLength(100);
    }
}

public class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title)
              .IsRequired()
              .HasMaxLength(50);

        builder.HasOne(e => e.Student)
              .WithMany(s => s.Courses)
              .HasForeignKey(e => e.StudentId);
    }
}
```

---

## 🧠 Étape 4 - Créer le DbContext

Le `DbContext` représente la session avec la base de données.

Dans `OnModelCreating`, on applique toutes les configs de l'assembly créé plus tôt


```csharp
public class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolContext).Assembly);
    }
}
```

---

# ➡️ Finalisation de la config

Dans appSettings.json, ajouter votre connection string

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "Main": "server=(localdb)\\MSSQLLocalDB;database=DemoEntity;integrated security=true;trust server certificate=true"
  }
}
```

Dans Program.cs, ajouter votre DbContext aux services

```csharp
builder.Services.AddDbContext<DbContext,SchoolContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("Main")));
```

---

### Ajouter une migration

Dans la console du gestionnaire de package

```bash
add-migration Init
```

Cela génère un fichier de migration dans le dossier `Migrations`.

### Appliquer la migration (créer la base de données)

```bash
Update-Database
```

---

## 🧪 Vérification

Utilise un outil comme **SQL Server Management Studio (SSMS)** ou **Azure Data Studio** pour explorer la base.

---

## 📚 Ressources utiles

* [Documentation EF Core](https://learn.microsoft.com/fr-fr/ef/core/)

---

> ✅ **Tips :** Toujours bien nommer les migrations (`AddStudentTable`, `UpdateCourseSchema`, etc.) pour garder l’historique lisible !
