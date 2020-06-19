namespace MediaBazaarSolution.Scheduling
{
    public class ScheduleUsers
    {
        public int ID { get; private set; }
        public bool[] noGoTimes { get; private set; }
        public int ContractedHours { get; private set; }
        public int noGoHours { get; private set; }

        public ScheduleUsers(int id, bool[] noGoTimes, int ContractedHours)
        {
            ID = id;
            this.noGoTimes = noGoTimes;
            this.ContractedHours = ContractedHours;
            this.noGoHours = setNoGoHours(noGoTimes);
        }

        //Set an int for easier sorting
        private int setNoGoHours(bool[] noGoTimes)
        {
            
            int sum = 0;
            for(int i = 0; i < noGoTimes.Length; i++ )
            {
                if (noGoTimes[i])
                {
                    sum++;
                }
            }

            return sum;
        }

    }
}