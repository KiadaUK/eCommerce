using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CumbriaMD.Domain;

namespace CumbriaMD.Infrastructure.DataServices
{
    public interface ICategoryDataService : IDataService
    {
        void ArrangeCategoriesOrderOnCreate(Category category);

        void ArrangeCategoriesOrderOnDelete(Category category);

        void ArrangeCategoriesOrderOnAction(Category category,
                                            List<Category> categories,
                                            Func<int, int> orderUpdateCalculator);

        IEnumerable<Category> GetAllSubcategories(int id);
    }
}
