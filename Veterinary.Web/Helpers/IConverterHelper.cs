using System.Threading.Tasks;
using Veterinary.Models;
using Veterinary.Web.Data.Entities;
using Veterinary.Web.Models;

namespace Veterinary.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Pet> ToPetAsync(PetViewModel model, string path,  bool isNew);

        PetViewModel ToPetViewModel(Pet pet);

        Task<History> ToHistoryAsync(HistoryViewModel model, bool isNew);

        HistoryViewModel ToHistoryViewModel(History history);

        PetResponse ToPetResponse(Pet pet);

        OwnerResponse ToOwnerResposne(Owner owner);


    }
}