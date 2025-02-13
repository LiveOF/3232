using Microsoft.AspNetCore.Identity;

namespace KooliProjekt.Data
{
    public static class SeedData
    {
        public static void Generate(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            if(context.TodoLists.Any())
            {
                return;
            }

            var adminUser = new IdentityUser
            {
                UserName = "admin",
                Email = "admin",
                EmailConfirmed = true,
            };

            userManager.CreateAsync(adminUser, "Password123!");

            var list = new TodoList();
            list.Title = "List 1";
            context.TodoLists.Add(list);

            // Veel andmeid

            context.SaveChanges();
        }
    }
}