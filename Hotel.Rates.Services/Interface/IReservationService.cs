using Hotel.Rates.Core;
using Hotel.Rates.Core.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Services.Interface
{
    public interface IReservationService
    {
        ServiceResult<double> MakeReservationNighlyPlan(ReservationTransferObject reservation);
        ServiceResult<double> MakeReservationIntervalPlan(ReservationTransferObject reservation);

    }
}
