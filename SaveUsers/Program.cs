using Pagination.Data;
using Pagination.Models;

string connectionString = "Data Source=d:\\Ruzimurod\\Projects\\Pagination\\Pagination\\Pagination.db";

using (ApplicationContext dbContext = new ApplicationContext(connectionString))
{
    dbContext.Companies.AddRange
    (
        new List<Company>
        {
            new Company { Id = 1, Name = "Factura" },
            new Company { Id = 2, Name = "Micros" },
            new Company { Id = 3, Name = "NAPA" },
            new Company { Id = 4, Name = "Exchange" }
        }
    );

    dbContext.SaveChanges();
    for (int i = 0; i < 15000; i++)
    {
        Random r = new Random();
        int rInt = r.Next(1, 4);
        int CompanyId = rInt;
        string name = "User_" + (i + 1);
        string email = "User_" + (i + 1) + "@mail.ru";
        string password = "User_" + (i + 1) + "P@ssw0rd";
        User user = new User
        {
            Email = email,
            Password = password,
            Name = name,
            Id = (i + 1),
            CompanyId = CompanyId
        };
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
    }
}
