using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CumbriaMD.Domain;
using LinqKit;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using Expression = System.Linq.Expressions.Expression;

namespace CumbriaMD.Infrastructure.DataServices
{
    //TODO: Refactor arranging categories orders methods
    //TODO: Work out how to implement ordering update method
    public class CategoryDataServices : ICategoryDataService
    {
        private readonly ISession _session;
        private readonly IEnumerable<Category> _objectSet; 

        public CategoryDataServices(ISession session)
        {
            _session = session;
            _objectSet = session.CreateCriteria<Category>().List<Category>();
        }


        //public void ArrangeCategoriesOrderOnCreate(Category category)
        //{
        //    var tx = _session.BeginTransaction();
        //    var categories = _session.QueryOver<Category>()
        //        .Where(c => c.Parent.Id == category.Parent.Id && c.OrderInList >= category.OrderInList)
        //        .List<Category>();

        //    foreach (var item in categories)
        //    {
        //        item.OrderInList++;
        //        _session.SaveOrUpdate(item);
        //    }
        //    tx.Commit();
        //}

        //public void ArrangeCategoriesOrderOnDelete(Category category)
        //{
        //    var tx = _session.BeginTransaction();
        //    var categories = _session.QueryOver<Category>()
        //        .Where(c => c.Parent.Id == category.Parent.Id && c.OrderInList > category.OrderInList)
        //        .List<Category>();

        //    foreach (var item in categories)
        //    {
        //        item.OrderInList--;
        //        _session.SaveOrUpdate(item);
        //    }
        //    tx.Commit();
        //}
    
        public IEnumerable<Category> GetAllSubcategories(int id)
        {

            var subcategories = _session.QueryOver<Category>()
                .Where(c => c.Parent.Id == id)
                .List<Category>()
                .OrderBy(c => c.OrderInList);


            return subcategories;

        }

        public void ArrangeCategoriesOrderOnCreate(Category category)
        {
          
            var categoriesToSort = _objectSet
                .Where(e => e.Parent.Id == category.Parent.Id
                            && e.OrderInList >= category.OrderInList)
                .ToList();

           ArrangeCategoriesOrderOnAction(category, categoriesToSort, x => x + 1);

        }

        public void ArrangeCategoriesOrderOnDelete(Category category)
        {
            var categoriesToSort = _objectSet
                .Where(e => e.Parent.Id == category.Parent.Id
                            && e.OrderInList > category.OrderInList)
                .ToList();

            ArrangeCategoriesOrderOnAction(category, categoriesToSort, x => x - 1);
        }


        public void ArrangeCategoriesOrderOnAction(Category category,
                                                   List<Category> categories,
                                                   Func<int, int> orderUpdateCalculator)
        {          
            var tx = _session.BeginTransaction();
            foreach (var item in categories)
            {
                item.OrderInList = orderUpdateCalculator(item.OrderInList);
                _session.SaveOrUpdate(item);
            }
            tx.Commit();
        }      
    }
}
