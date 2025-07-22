namespace TF_Net_IOT_DemoEntityFramework.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        // Il vaut mieux encapsuler les collections sans set mais avec methode add / remove + get copy
        // Toujours s'assurer que les collections ne sont pas null
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
