namespace ApiExamen
{
    public class ClsExamen
    {
        private readonly string _connectionString;

        public ClsExamen(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<string> AgregarAsync(string name, string description, bool useApi)
        {
            if(useApi)
            {
                var apiClient = new ApiClient();
                return await apiClient.AgregarAsync(name, description);
            }

            var adoClient = new AdoClient(_connectionString);
            return await adoClient.AgregarAsync(name, description);
        }

        public async Task<string> ActualizarAsync( int id,string name, string description, bool useApi)
        {
            if (useApi)
            {
                var apiClient = new ApiClient();
                return await apiClient.ActualizarAsync(id,name, description);
            }

            var adoClient = new AdoClient(_connectionString);
            return await adoClient.ActualizarAsync(id,name, description);
        }

        public async Task<string> EliminarAsync(int id, bool useApi)
        {
            if (useApi)
            {
                var apiClient = new ApiClient();
                return await apiClient.EliminarAsync(id);
            }

            var adoClient = new AdoClient(_connectionString);
            return await adoClient.EliminarAsync(id);
        }

        public async Task<string> ConsultarAsync(string name, string description, bool useApi)
        {
            if (useApi)
            {
                var apiClient = new ApiClient();
                return await apiClient.ConsultarAsync(name, description);
            }

            var adoClient = new AdoClient(_connectionString);
            return await adoClient.ConsultarAsync(name, description);
        }

    }
}