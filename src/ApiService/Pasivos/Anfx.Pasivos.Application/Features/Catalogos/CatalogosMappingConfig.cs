using Anfx.Pasivos.Application.Features.Catalogos.DTOs;
using Mapster;

namespace Anfx.Pasivos.Application.Features.Catalogos;

public class CatalogosMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PSV_TipoCredito, TipoCreditoListItemDto>()
            .Map(o => o.Id, d => d.IdTipoCredito); 

    }
}
