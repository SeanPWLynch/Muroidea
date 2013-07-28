// -----------------------------------------------------------------------
// <copyright file="ScheduledTask.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Communication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32.TaskScheduler;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// 
    [Serializable]
    public class ScheduledTask
    {
        string taskName;
        string taskDescription;

        [NonSerialized]
        TaskService task;

        [NonSerialized]
        TaskDefinition taskDef;

        [NonSerialized]
        List<Trigger> triggers;

        [NonSerialized]
        List<ExecAction> actions;

        List<SerialAction> serialActions; //To serialize
        List<SerialTrigger> serialTriggers; //To serialize

        /*
        [NonSerialized]
        private DateTime date;


        string dateString
        {
            get { return date.ToString("MM/dd/yy H:mm:ss"); }
            set { date = DateTime.Parse(value); }
        }

        [NonSerialized]
        DateTime stopDate;

        string stopDateString
        {
            get { return stopDate.ToString("MM/dd/yy H:mm:ss"); }
            set { stopDate = DateTime.Parse(value); }
        }

        bool isRepeat;
        int minutesBetweenEachRepeat = 0;
        int hoursBetweenEachRepeat = 0;
        int daysBetweenEachRepeat = 0;
        int weeksBetweenEachRepeat = 0;
        int monthsBetweenEachRepeat = 0;
        int yearsBetweenEachRepeat = 0;
        string batchFileToRun; //location of the bat file to run.
        */

        public List<SerialAction> GetSerialActions()
        {
            return this.serialActions;
        }

        public List<SerialTrigger> GetSerialTriggers()
        {
            return this.serialTriggers;
        }

        public string GetTaskName()
        {
            return this.taskName;
        }

        public string GetTaskDescription()
        {
            return this.taskDescription;
        }

        public ScheduledTask(string taskName, string taskDescription)
        {
            this.taskName = taskName;
            this.taskDescription = taskDescription;
            task = new TaskService();
            taskDef = task.NewTask();
            this.serialActions = new List<SerialAction>();
            this.serialTriggers = new List<SerialTrigger>();
            this.triggers = new List<Trigger>();
            this.actions = new List<ExecAction>();
        }

        public ScheduledTask(string taskName, string taskDescription, string path)
            : this(taskName, taskDescription)
        {
            taskDef.Actions.Add(new ExecAction(path, "muroideaSchedules.log", null));
        }

        public void RegisterTask()
        {
            //taskDef.Actions.Add(new ExecAction();
            taskDef.RegistrationInfo.Description = this.taskDescription;
            task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
            //taskDef.Actions.RemoveAt(0);
        }

        public string CopyTriggers(List<Trigger> triggers)
        {
            this.triggers = triggers;
            foreach (Trigger t in this.triggers)
            {
                if (t != null)
                {
                    SerialTrigger st = new SerialTrigger(t.TriggerType.ToString(), t.ToString(), t.Enabled.ToString());
                    serialTriggers.Add(st);
                }
            }
            return "Done";
        }

        public string CopyActions(List<ExecAction> actions)
        {
            this.actions = actions;
            foreach (ExecAction a in this.actions)
            {
                if (a != null)
                {
                    SerialAction sa = new SerialAction(a.ActionType.ToString(), a.Path.ToString());
                    serialActions.Add(sa);
                    taskDef.Actions.Add(new ExecAction(a.Path, "muroideaSchedules.log", null));
                }
            }
            return "Done";
        }

        public string AddDailyTrigger(DateTime startTime, int everyMinute = -1)
        {
            DailyTrigger dt = new DailyTrigger();
            if (everyMinute != -1)
            {
                dt.Repetition.Interval = TimeSpan.FromMinutes(everyMinute);
            }
            dt.StartBoundary = startTime;
            taskDef.Triggers.Add(dt);
            triggers.Add(dt);
            task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
            return "Added";
        }

        public string AddWeeklyTrigger(DateTime startTime)
        {
            WeeklyTrigger wt = new WeeklyTrigger();
            wt.StartBoundary = startTime;
            taskDef.Triggers.Add(wt);
            triggers.Add(wt);
            task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
            return "Added";
        }

        
        public string AddMonthlyTrigger(DateTime startTime)
        {
            MonthlyTrigger mt = new MonthlyTrigger();
            mt.StartBoundary = startTime;
            taskDef.Triggers.Add(mt);
            triggers.Add(mt);
            task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
            return "Added";
        }

       

        public string AddStartupTrigger()
        {
            try
            {
                LogonTrigger lot = new LogonTrigger();
                taskDef.Triggers.Add(lot);
                triggers.Add(lot);
                task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
                return "Added";
            }
            catch (Exception e)
            {
                return "Access Denied";
            }
        }

        /*
        public string RegisterTask()
        {
            TaskService task = new TaskService();
            TaskDefinition taskDef = task.NewTask();
            taskDef.RegistrationInfo.Description = this.taskDescription;
            taskDef.Triggers.Add(new TimeTrigger(this.date));

            if (this.minutesBetweenEachRepeat != 0)
            {
                DailyTrigger dt = new DailyTrigger();
                TimeSpan difference = stopDate - date;
                dt.Repetition.Interval = TimeSpan.FromMinutes(minutesBetweenEachRepeat);
                dt.Repetition.Duration = TimeSpan.FromMinutes(difference.TotalMinutes);
                dt.EndBoundary = stopDate;
                taskDef.Triggers.Add(dt);
            }

            if (this.hoursBetweenEachRepeat != 0)
            {
                DailyTrigger dt = new DailyTrigger();
                TimeSpan difference = stopDate - date;
                dt.Repetition.Interval = TimeSpan.FromHours(hoursBetweenEachRepeat);
                dt.Repetition.Duration = TimeSpan.FromHours(difference.TotalHours);
                dt.EndBoundary = stopDate;
                taskDef.Triggers.Add(dt);
            }

            if (this.daysBetweenEachRepeat != 0)
            {
                DailyTrigger dt = new DailyTrigger();
                TimeSpan difference = stopDate - date;
                dt.DaysInterval = (short)daysBetweenEachRepeat;
                dt.EndBoundary = stopDate;
                taskDef.Triggers.Add(dt);
            }

            if (this.weeksBetweenEachRepeat != 0)
            {
                WeeklyTrigger wt = new WeeklyTrigger();
                TimeSpan difference = stopDate - date;
                wt.WeeksInterval = (short)weeksBetweenEachRepeat;
                wt.EndBoundary = stopDate;
                taskDef.Triggers.Add(wt);
            }
            if (this.monthsBetweenEachRepeat != 0)
            {
                MonthlyTrigger mt = new MonthlyTrigger();
                TimeSpan difference = stopDate - date;
                mt.StartBoundary = date;
                mt.EndBoundary = stopDate;
                taskDef.Triggers.Add(mt);
            }

            // Create an action that will launch Notepad whenever the trigger fires
            taskDef.Actions.Add(new ExecAction(batchFileToRun, "muroideaSchedules.log", null));

            // Register the task in the root folder
            task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef);

            return "Registered";
        }
         * */



        public string AddAction(string path)
        {
            taskDef.Actions.Add(new ExecAction(path, "muroideaSchedules.log", null));
            task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
            return "Done";
        }

        public void DeleteTrigger(int triggerIndex)
        {
            triggers.RemoveAt(triggerIndex);
            serialTriggers.RemoveAt(triggerIndex);
            task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
        }

        public void DeleteTask()
        {
            task.RootFolder.DeleteTask(taskName);
        }

        public void DeleteAction(int actionIndex)
        {
            actions.RemoveAt(actionIndex);
            serialActions.RemoveAt(actionIndex);
            taskDef.Actions.RemoveAt(actionIndex);
            task.RootFolder.RegisterTaskDefinition(this.taskName, taskDef, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, null);
        }
    }

    [Serializable]
    public class SerialAction
    {
        string ActionName;
        string FileToRun;

        public SerialAction(string actionName, string fileToRun)
        {
            this.ActionName = actionName;
            this.FileToRun = fileToRun;
        }

        public string GetName()
        {
            return this.ActionName;
        }

        public string GetFileToRun()
        {
            return this.FileToRun;
        }
    }

    [Serializable]
    public class SerialTrigger
    {
        string TriggerName;
        string TriggerDetails;
        string TriggerStatus;

        public SerialTrigger(string TriggerName, string TriggerDetails, string TriggerStatus)
        {
            this.TriggerDetails = TriggerDetails;
            this.TriggerName = TriggerName;
            this.TriggerStatus = TriggerStatus;
        }

        public string GetName()
        {
            return this.TriggerName;
        }

        public string GetDetails()
        {
            return this.TriggerDetails;
        }

        public string GetStatus()
        {
            return this.TriggerStatus;
        }

    }

}
