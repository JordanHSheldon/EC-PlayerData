namespace EsportsProfileWebApi.INFRASTRUCTURE;

using EsportsProfileWebApi.CROSSCUTTING.Requests.Data;
using EsportsProfileWebApi.CROSSCUTTING.Responses.Data;

public interface IDataRepository
{
    public GetDataResponse GetData(GetDataRequest dataRequest);

    public IEnumerable<GetDataResponse> GetAllData(GetDataRequest dataRequest);

    bool UpdateData(UpdateDataRequest request);
}

