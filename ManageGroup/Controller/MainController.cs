using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageGroup.DAL;
using ManageGroup.Domain;

namespace ManageGroup.Controller
{
    public class MainController
    {
        public static List<Activity> GetActivities()
        {
            var db = new LocalStorage();
            return db.Activities;
        }

        public static void AddActivities(Activity activity)
        {
            var db = new LocalStorage();
            activity.ID = 0;

            db.Activities.Add(activity);
            db.SaveChanges();
        }

        public static void DeleteActivities(Activity activity)
        {
            var db = new LocalStorage();
            db.Activities.RemoveAll(x => x.ID == activity.ID);
            db.SaveChanges();
        }

        public static void UpdateAct(Activity activity)
        {
            var db = new LocalStorage();

                var updateAct = db.Activities.FirstOrDefault(x => x.ID == activity.ID);
                if (updateAct != null)
                {
                    updateAct.NameActivity = activity.NameActivity;
                    updateAct.status = activity.status;
                    updateAct.TimeEnd = activity.TimeEnd;
                    updateAct.TimeStart = activity.TimeStart;
                    updateAct.TypeActivity = activity.TypeActivity;
                    updateAct.DateEnd = activity.DateEnd;
                    updateAct.DateStart = activity.DateStart;
                    updateAct.Duration = activity.Duration;

                    db.SaveChanges();
                }
        }

        public static List<Status> GetStatus()
        {
            var db = new LocalStorage();
            return db.ActivityStatusList;
        }

        public static List<TypeComp> GetTypeActivity()
        {
            var db = new LocalStorage();
            return db.ActivityTypeList;
        }
    }
}
