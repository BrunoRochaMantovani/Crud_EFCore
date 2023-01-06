using Curso_Entity.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            //------CREATE------\\
            var postAdd = new Post { Title = "Como comer uva sem semente", Summary = "Tutorial de uvas", Body = "Só mastigar mano", Slug = "Facil para caramba", CreateDate = DateTime.Now, LastUpdateDate = DateTime.Now, AuthorId = 1, CategoryId = 1 };

            context.Add(postAdd);

            context.SaveChanges();


            //------UPDATE------\\
            System.Console.WriteLine("_____________________UPDATE_____________________");
            var selectByIdToUpdate = context
                .Post
                .AsNoTracking()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == 11);
            selectByIdToUpdate.Title = "Titulo alterado";

            context.Update(selectByIdToUpdate);

            context.SaveChanges();

            System.Console.WriteLine($"\n\nId do Post : {selectByIdToUpdate.Id}\nTitulo do Post : {selectByIdToUpdate.Title}\nCategoria do Post : {selectByIdToUpdate.Category?.Name}\nAutor do Post : {selectByIdToUpdate.Author?.Name}\n");
            System.Console.WriteLine("_____________________________________________________\n");
            //------SELECT------\\
            System.Console.WriteLine("_____________________SELECT ALL_____________________");
            var selectAll = context
                .Post
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderBy(x => x.CreateDate)
                .ToList();

            foreach (var posts in selectAll)
            {
                System.Console.WriteLine($"\n\nId do Post : {posts.Id}\nTitulo do Post : {posts.Title}\nCategoria do Post : {posts.Category?.Name}\nAutor do Post : {posts.Author?.Name}\n");
            }
            System.Console.WriteLine("_____________________________________________________\n");
            System.Console.WriteLine("_____________________SELECT BY ID_____________________");



            //------SELECT BY ID------\\
            var selectById = context
                .Post
                .Include(x => x.Author)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == 11);

            System.Console.WriteLine($"\n\nId do Post : {selectById.Id}\nTitulo do Post : {selectById.Title}\nCategoria do Post : {selectById.Category?.Name}\nAutor do Post : {selectById.Author?.Name}\n");
            System.Console.WriteLine("_____________________________________________________\n");

            //------DELETE------\\
            System.Console.WriteLine("_____________________DELETE_____________________");

            var selectByDelete = context
                .Post
                .Include(x => x.Author)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == 11);

            context.Remove(selectByDelete);

            System.Console.WriteLine("-----_Post Excluido_-----");

            System.Console.WriteLine($"\n\nId do Post : {selectByDelete.Id}\nTitulo do Post : {selectByDelete.Title}\nCategoria do Post : {selectByDelete.Category?.Name}\nAutor do Post : {selectByDelete.Author?.Name}\n");

            System.Console.WriteLine("_____________________________________________________\n");


        }
    }
}