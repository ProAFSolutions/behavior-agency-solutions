using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorAgency.Services.Dto
{
    public interface IDtoEntityMapper<E>
    {
        E MapToEntity();

        void MapFromEntity();
    }
}
