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
            this.finalScheduleUsers = assignSchedule();
        }

        private ScheduleUsers[] sortScheduleUsers(ScheduleUsers[] array)
        {
            ScheduleUsers temp;
            for (int j = 0; j <= array.Length - 2; j++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    if (array[i].noGoHours < array[i + 1].noGoHours)
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
            // Loop through employees
            foreach(ScheduleUsers user in scheduleUsers)
            {
                // Loop through Contracted Hours
                for (int i = 0; i < user.ContractedHours; i++)
                {
                    bool done = false;
                    int timesAvailableHad = 0;
                    // Loop through timeslots
                    for (int j = 0; j < 21; j++)
                    {
                        // Check if timeslot is available and relevant
                        if(!(user.noGoTimes[j]) && timesAvailable[j])
                        {
                            timesAvailable[j] = false;
                            schedule[j] = user;
                            
                            break;
                        }
                        // Check if timeslot was relevant for counting purposes
                        if (!user.noGoTimes[j])
                        {
                            timesAvailableHad++;
                        }
                        // If the amount of available timeslots is the amount of hours they cannot work
                        if (timesAvailableHad == (21-user.noGoHours))
                        {
                            // Loop backwards through the previous timeslots
                            for (int n = j; n > 0; n--)
                            {
                                // Loop forwards through the timeslots
                                for (int p = n; p < 21; p++)
                                {
                                    // If there is a person scheduled at timeslot n
                                    if (schedule[n] != null)
                                    {
                                        // If the person at timeslot n can work at timeslot p and timeslot p is available schedule them in there, and put the original user at timeslot n
                                        if (!(schedule[n].noGoTimes[p]) && timesAvailable[p])
                                        {
                                            timesAvailable[p] = false;
                                            schedule[p] = schedule[n];
                                            schedule[n] = user;
                                            done = true;
                                            break;

                                        }
                                    }
                                }
                                if (done)
                                {
                                    break;
                                }
                            }
                            
                            break;
                            
                        }
                        
                    }
                }
            }
            
            return schedule;
        }

        public ScheduleUsers[] getSchedule()
        {

            return finalScheduleUsers;
        }


    }
}
