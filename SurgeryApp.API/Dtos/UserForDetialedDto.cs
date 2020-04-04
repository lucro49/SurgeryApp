using System.Collections.Generic;
using SurgeryApp.API.Models;

namespace SurgeryApp.API.Dtos
{
    public class UserForDetialedDto
    {
           public int Id { get; set; }
        public string Username { get; set; } 
        public string Gender { get; set; } 
        public int Age { get; set; } 
        public string KnownAs {get; set;}
        public string Created { get; set; } 
        public string LastActive { get; set; } 
        public string Introduction { get; set; }  
        public string City {get; set;} 
        public string Country {get; set;}   
        public string PhotosUrl {get; set;} 
        public ICollection<PhotosForDetailedDto> Photos {get; set;} 
    }
}