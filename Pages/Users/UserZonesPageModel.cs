using CronosegAccess.Models;
using CronosegAccess.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronosegAccess.Pages.Users
{
    public class UserZonesPageModel:PageModel
    {
        public List<AssignedZoneData> AssignedZoneDataList;
        public List<AssignedScheduleData> AssignedScheduleDataList;

        //LISTADO ZONAS
        public void PopulateAssignedZoneData(Data.CronosegAccessContext context,
                                               accUser user)
        {
            var allZones = context.accZone;
            var userZones = new HashSet<int>(
                user.UserZones.Select(c => c.idZone));
            AssignedZoneDataList = new List<AssignedZoneData>();
            foreach (var zone in allZones)
            {
                AssignedZoneDataList.Add(new AssignedZoneData
                {
                    idZone = zone.IdZone,
                    Name = zone.Name,
                    Assigned = userZones.Contains(zone.IdZone)
                });
            }
        }

        public void UpdateUserZones(Data.CronosegAccessContext context,
            string[] selectedZones, accUser UserToUpdate)
        {
            if (selectedZones == null)
            {
                UserToUpdate.UserZones = new List<accUserZone>();
                return;
            }

            var selectedZonesHS = new HashSet<string>(selectedZones);
            var userZones = new HashSet<int>
                (UserToUpdate.UserZones.Select(c => c.zone.IdZone));
            foreach (var zone in context.accZone)
            {
                if (selectedZonesHS.Contains(zone.IdZone.ToString()))
                {
                    if (!userZones.Contains(zone.IdZone))
                    {
                        UserToUpdate.UserZones.Add(
                            new accUserZone
                            {
                                idUser = UserToUpdate.idUser,
                                idZone = zone.IdZone
                            });
                    }
                }
                else
                {
                    if (userZones.Contains(zone.IdZone))
                    {
                        accUserZone zoneToRemove
                            = UserToUpdate
                                .UserZones
                                .SingleOrDefault(i => i.idZone == zone.IdZone);
                        context.Remove(zoneToRemove);
                    }
                }
            }
        }

        //LISTADO HORARIOS
        public void PopulateAssignedScheduleData(Data.CronosegAccessContext context,
                                       accUser user)
        {
            var allSchedules = context.accSchedule;
            var userSchedules = new HashSet<int>(
                user.UserSchedules.Select(c => c.idSchedule));
            AssignedScheduleDataList = new List<AssignedScheduleData>();
            foreach (var schedule in allSchedules)
            {
                AssignedScheduleDataList.Add(new AssignedScheduleData
                {
                    idSchedule = schedule.IdSchedule,
                    Name = schedule.Name,
                    Assigned = userSchedules.Contains(schedule.IdSchedule)
                });
            }
        }

        public void UpdateUserSchedules(Data.CronosegAccessContext context,
            string[] selectedZones, accUser UserToUpdate)
        {
            if (selectedZones == null)
            {
                UserToUpdate.UserZones = new List<accUserZone>();
                return;
            }

            var selectedZonesHS = new HashSet<string>(selectedZones);
            var userZones = new HashSet<int>
                (UserToUpdate.UserZones.Select(c => c.zone.IdZone));
            foreach (var zone in context.accZone)
            {
                if (selectedZonesHS.Contains(zone.IdZone.ToString()))
                {
                    if (!userZones.Contains(zone.IdZone))
                    {
                        UserToUpdate.UserZones.Add(
                            new accUserZone
                            {
                                idUser = UserToUpdate.idUser,
                                idZone = zone.IdZone
                            });
                    }
                }
                else
                {
                    if (userZones.Contains(zone.IdZone))
                    {
                        accUserZone zoneToRemove
                            = UserToUpdate
                                .UserZones
                                .SingleOrDefault(i => i.idZone == zone.IdZone);
                        context.Remove(zoneToRemove);
                    }
                }
            }
        }
    }
}
