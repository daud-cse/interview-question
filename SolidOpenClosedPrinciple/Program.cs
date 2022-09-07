using System;
using System.Text;

namespace SolidOpenClosedPrinciple
{
    public class DeveloperReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int WorkingHours { get; set; }
        public double HourlyRate { get; set; }
    }
    public abstract class BaseSalaryCalculator
    {
        protected DeveloperReport DeveloperReport { get; private set; }

        public BaseSalaryCalculator(DeveloperReport developerReport)
        {
            DeveloperReport = developerReport;
        }

        public abstract double CalculateSalary();
    }
    public class SeniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public SeniorDevSalaryCalculator(DeveloperReport report)
            : base(report)
        {
        }

        public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
    }
    public class JuniorDevSalaryCalculator : BaseSalaryCalculator
    {
        public JuniorDevSalaryCalculator(DeveloperReport developerReport)
            : base(developerReport)
        {
        }

        public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
    }
    public class SalaryCalculatorOCP
    {
        private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;

        public SalaryCalculatorOCP(IEnumerable<BaseSalaryCalculator> developerCalculation)
        {
            _developerCalculation = developerCalculation;
        }

        public double CalculateTotalSalaries()
        {
            double totalSalaries = 0D;

            foreach (var devCalc in _developerCalculation)
            {
                totalSalaries += devCalc.CalculateSalary();
            }

            return totalSalaries;
        }
    }
    public class SalaryCalculator
    {
        private readonly IEnumerable<DeveloperReport> _developerReports;

        public SalaryCalculator(List<DeveloperReport> developerReports)
        {
            _developerReports = developerReports;
        }

        public double CalculateTotalSalaries()
        {
            double totalSalaries = 0D;

            foreach (var devReport in _developerReports)
            {
                totalSalaries += devReport.HourlyRate * devReport.WorkingHours;
            }

            return totalSalaries;
        }
    }
    class Program
    {
        //https://code-maze.com/open-closed-principle/
        //Why Should We Implement the Open Closed Principle
        //By implementing the OCP we are lowering the chance of producing bugs in our project.

        //For example, if we have a fully working and already tested
        //class in production, by extending it instead of changing it,
        //we would definitely have a lesser impact on the rest of the system.

        //Therefore, we introduce another class to extend the behavior
        //of the main class thus avoid the existing functionality
        //modification that other classes may rely upon.

        //Another benefit is that we only have to
        //test and deploy the new features,
        //which wouldn’t be the case
        //if we had to change existing functionality.Furthermore,
        //if we decide that we don’t need this feature anymore (sometime in the future)
        //, all we have to do is to revert just newly implemented change and that’s it.
        static void Main(string[] args)
        {
            var devReports = new List<DeveloperReport>
                                {
                                    new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 160 },
                                    new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate  = 20, WorkingHours = 150 },
                                    new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate  = 30.5, WorkingHours = 180 }
                                };

            var calculator = new SalaryCalculator(devReports);
            Console.WriteLine($" Normal Sum of all the developer salaries is {calculator.CalculateTotalSalaries()} dollars");



            var devCalculations = new List<BaseSalaryCalculator>
                                        {
                                            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 1, Name = "Dev1", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 160 }),
                                            new JuniorDevSalaryCalculator(new DeveloperReport {Id = 2, Name = "Dev2", Level = "Junior developer", HourlyRate = 20, WorkingHours = 150 }),
                                            new SeniorDevSalaryCalculator(new DeveloperReport {Id = 3, Name = "Dev3", Level = "Senior developer", HourlyRate = 30.5, WorkingHours = 180 })
                                        };
            var calculatorOCP = new SalaryCalculatorOCP(devCalculations);
            Console.WriteLine($"OCP Sum of all the developer salaries is {calculatorOCP.CalculateTotalSalaries()} dollars");
        }
    }
}