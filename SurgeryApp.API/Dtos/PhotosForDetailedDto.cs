using System;

namespace SurgeryApp.API.Dtos
{
    public class PhotosForDetailedDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}