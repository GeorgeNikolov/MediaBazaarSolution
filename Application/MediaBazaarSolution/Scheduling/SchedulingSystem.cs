using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSolution.Scheduling
{
    class SchedulingSystem
    {
        ScheduleUsers[] scheduleUsers;
        bool[] timesAvailable;
        private ScheduleUsers[] finalScheduleUsers = new ScheduleUsers[21];
        public SchedulingSystem(List<ScheduleUsers> employees, bool[] timesAvailable)
        {

            this.scheduleUsers = sortScheduleUsers(employees.ToArray());
            this.timesAvailable = timesAvailable;
            assignSchedule();
        }

        private ScheduleUsers[] sortScheduleUsers(ScheduleUsers[] array)
        {
            ScheduleUsers temp;
            for (int j = 0; j <= array.Length - 2; j++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if (array[i].noGoHours > array[i + 1].noGoHours)
                    {
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    }

                }
            }
            return array;
        }

        private ScheduleUsers[] assignSchedule()
        {
            ScheduleUsers[] schedule = new ScheduleUsers[21];
            foreach(ScheduleUsers user in scheduleUsers)
            {
                for (int i = 0; i < user.ContractedHours; i++)
                {
                    bool done = false;
                    int timesAvailableHad = 0;
                    for (int j = 0; j < 21; j++)
                    {
                        if(!(user.noGoTimes[j]) && timesAvailable[j])
                        {
                            timesAvailable[j] = false;
                            schedule[j] = user;
                            
                            break;
                        }
                        if (user.noGoTimes[j])
                        {
                            timesAvailableHad++;
                        }

                        if (timesAvailableHad == user.noGoHours)
                        {
                            for (int n = j; n > 0; n--)
                            {
                                for (int p = n; p < 21; p++)
                                {
                                    if (!(schedule[n].noGoTimes[p]) && timesAvailable[p])
                                    {
                                        timesAvailable[p] = false;
                                        schedule[p] = schedule[n];
                                        schedule[n] = user;
                                        done = true;
                                        break;
                                        
                                    }
                                }
                                if (done)
                                {
                                    break;
                                }
                            }
                            if (!done)
                            {
                                // Here the error message must come
                            } else
                            {
                                break;
                            }
                        }
                        
                    }
                }
            }

            return null;
        }

        public ScheduleUsers[] getSchedule()
        {

            return finalScheduleUsers;
        }


    }
}
