using _2Core.Interfaces.Services;

namespace _2Core.Services;

public class EService : IEService
{
    public async Task<ApiGenericResult<CallApiDTO>> CallAPI(string insurance, string token)
    {
        if(token == null)
        {
            throw new Exception("token not found");
        }
        var dto = new CallApiDTO{
            name = "Chatchai Plukchalee",
            taxid = "9087654321321",
            travel_license = "9087654321321",
            telephone = "0898612041",
            email = "chatchai.p@gmail.com",
            address_no = "565 ",
            address_moo = "13",
            address_building = "building 1",
            address_soi = "soi",
            address_road = "read",
            address_subdistrict = "subdistrict",
            address_district = "district",
            address_province = "province",
            address_postcode = "10320",
        };

        var rs = new ApiGenericResult<CallApiDTO>{
            results = dto
        };
        return rs;
    }
}
