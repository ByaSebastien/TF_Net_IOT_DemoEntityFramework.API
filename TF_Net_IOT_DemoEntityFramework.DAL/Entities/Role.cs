﻿namespace TF_Net_IOT_DemoEntityFramework.DAL.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<User> Users { get; set; } = new List<User>();
    }
}
