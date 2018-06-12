namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data.Models;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.DBContext.MyShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.DBContext.MyShopDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            // Code khi chạy DB sẽ tự chạy
            CreateAdmin(context);
            
        }
        private string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
        private void CreateAdmin(Data.DBContext.MyShopDBContext context)
        {
            if(context.Admin.Where(x=> x.UserName == "Administrator").Count() == 0)
            {
                Admin admin = new Admin();
                admin.UserName = "Administrator";
                admin.PasswordHash = Encryptdata("Ab@123456");
                admin.FirstName = "Nguyễn Văn";
                admin.LastName = "Tiệp";
                admin.PhoneNumber = "01654911732";
                admin.Address = "Đéo có";
                context.Admin.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
