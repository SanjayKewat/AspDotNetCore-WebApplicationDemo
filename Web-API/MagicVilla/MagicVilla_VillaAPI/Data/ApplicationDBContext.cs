using Microsoft.EntityFrameworkCore;
using MagicVilla_VillaAPI.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        //here pass the DBContext & pass into "DbContext" class using  base(options)
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
        public DbSet<Villa> Villas { get; set; }   //based on "Villas" name same table created into the DB using code first appproach           


        //insert the some dummy data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Pool View",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.guim.co.uk%2Fimg%2Fstatic%2Fsys-images%2FGuardian%2FPix%2Fpictures%2F2014%2F3%2F21%2F1395401774125%2FLorem-ipsum-011.jpg%3Fwidth%3D465%26dpr%3D1%26s%3Dnone&tbnid=vRZtDL4gTwkgMM&vet=12ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw..i&imgrefurl=https%3A%2F%2Fwww.theguardian.com%2Fbooks%2Fbooksblog%2F2014%2Fmar%2F21%2Florem-ipsum-translated-latin-placeholder-text&docid=Q_SoORA3siVI3M&w=460&h=276&q=lorem%20ipsum&ved=2ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 550,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Royal View",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.guim.co.uk%2Fimg%2Fstatic%2Fsys-images%2FGuardian%2FPix%2Fpictures%2F2014%2F3%2F21%2F1395401774125%2FLorem-ipsum-011.jpg%3Fwidth%3D465%26dpr%3D1%26s%3Dnone&tbnid=vRZtDL4gTwkgMM&vet=12ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw..i&imgrefurl=https%3A%2F%2Fwww.theguardian.com%2Fbooks%2Fbooksblog%2F2014%2Fmar%2F21%2Florem-ipsum-translated-latin-placeholder-text&docid=Q_SoORA3siVI3M&w=460&h=276&q=lorem%20ipsum&ved=2ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw",
                    Occupancy = 15,
                    Rate = 300,
                    Sqft = 250,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Royal View",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.guim.co.uk%2Fimg%2Fstatic%2Fsys-images%2FGuardian%2FPix%2Fpictures%2F2014%2F3%2F21%2F1395401774125%2FLorem-ipsum-011.jpg%3Fwidth%3D465%26dpr%3D1%26s%3Dnone&tbnid=vRZtDL4gTwkgMM&vet=12ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw..i&imgrefurl=https%3A%2F%2Fwww.theguardian.com%2Fbooks%2Fbooksblog%2F2014%2Fmar%2F21%2Florem-ipsum-translated-latin-placeholder-text&docid=Q_SoORA3siVI3M&w=460&h=276&q=lorem%20ipsum&ved=2ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw",
                    Occupancy = 15,
                    Rate = 21,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Royal View",
                    Details = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    ImageUrl = "https://www.google.com/imgres?imgurl=https%3A%2F%2Fi.guim.co.uk%2Fimg%2Fstatic%2Fsys-images%2FGuardian%2FPix%2Fpictures%2F2014%2F3%2F21%2F1395401774125%2FLorem-ipsum-011.jpg%3Fwidth%3D465%26dpr%3D1%26s%3Dnone&tbnid=vRZtDL4gTwkgMM&vet=12ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw..i&imgrefurl=https%3A%2F%2Fwww.theguardian.com%2Fbooks%2Fbooksblog%2F2014%2Fmar%2F21%2Florem-ipsum-translated-latin-placeholder-text&docid=Q_SoORA3siVI3M&w=460&h=276&q=lorem%20ipsum&ved=2ahUKEwicp9fIusCCAxWToekKHb0QBLkQMygBegQIARBw",
                    Occupancy = 20,
                    Rate = 150,
                    Sqft = 100,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                    IsActive = true
                }
                );
        }
    }
}
