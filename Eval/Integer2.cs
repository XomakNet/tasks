namespace EvalTask
{
    class Integer2 : Primary
    {
        private double value;

        public Integer2(string number)
        {
            value = double.Parse(number);
        }
    }
}