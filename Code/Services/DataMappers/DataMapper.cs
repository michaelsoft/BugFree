namespace MichaelSoft.BugFree.WebApi.DataMappers
{
    public static class DataMapper
    {
        public static void Map()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.AddProfile<BugProfile>();
            }
            );
        }
    }
}
