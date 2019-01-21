using Haarlem_Festival.Models.Domain_Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haarlem_Festival.Repositories.Events
{
    interface IEventRepository
    {
        Event GetEvent(int eventId);
        Event GetEventByRestaurantId(int restaurantId);

    }
}
