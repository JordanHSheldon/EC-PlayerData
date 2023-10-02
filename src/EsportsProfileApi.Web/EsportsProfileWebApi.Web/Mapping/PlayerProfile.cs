namespace EsportsProfileWebApi.Web.Mapping
{
    using AutoMapper;
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            MapData();
        }

        public void MapData()
        {
            // make mapping sections for settings and such.
            CreateMap<int, int>();
        }
    }
}