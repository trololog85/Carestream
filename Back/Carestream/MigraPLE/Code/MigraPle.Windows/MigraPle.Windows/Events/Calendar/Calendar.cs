namespace MigraPle.Windows.Search
{
    public partial class CalendarPeriodo
    {
        public void GetPeriodo()
        {
            if (this.clPeriodo.SelectedDate.HasValue)
                this.FechaPeriodo = this.clPeriodo.SelectedDate.Value;

            this.Close();
        }
    }
}
