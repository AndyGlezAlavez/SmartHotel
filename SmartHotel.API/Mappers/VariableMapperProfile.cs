using SmartHotel.GrpcProtos;

namespace SmartHotel.API.Mappers
{
    public static class UnitMapperProfile
    {
        // Conversión de Unit a UnitDTO
        public static VariableDTO Map(this Domain.Entities.Variable variable)
        {
            return new VariableDTO()
            {
                Id = variable.Id.ToString(),
                Reference = variable.Reference,
                Value = variable.Value,
            };
        }

        public static Variables Map(this IEnumerable<Domain.Entities.Variable> list)
        {
            var dto = new Variables();
            dto.Items.AddRange(list.Select(u => u.Map()));
            return dto;
        }
    }
}