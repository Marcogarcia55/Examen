using System.Data;
using Dapper;
using ExamenApi.Repositories;
using Microsoft.Data.SqlClient;

namespace ExamenApi
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public FacturaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("");
        }

        public async Task<Factura> AddAsync(Factura factura)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Factura>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Factura>("spGetAllFactura", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FacturaDetalleDto>> GetByFecha(FacturaFechaDto fechaDto)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<FacturaDetalleDto>("sp_GetFacturaByFecha", 
            new{fechaDto.FechaInicio, fechaDto.FechaFin} ,commandType: CommandType.StoredProcedure);
        }
    }
}