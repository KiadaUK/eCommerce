using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CumbriaMD.Tests.Category_Tests {

       public class TestCategories
       {
           public int Id { get; set; }
           public int OrderInList { get; set; }
           public int ParentId { get; set; }
           public IList<TestCategories> Subcategories { get; set; }

           public TestCategories()
           {
               Subcategories = new List<TestCategories>();
           }
       }

    public class blah {
       static public IList<TestCategories> GetTestCategories()
        {

            var topCategoryOne = new TestCategories() { Id = 1, ParentId = 0, OrderInList = 1 };
            var topCategoryTwo = new TestCategories() { Id = 4, ParentId = 3, OrderInList = 1 };
            var topCategoryThree = new TestCategories() { Id = 2, ParentId = 1, OrderInList = 1 };
            var subCategoryOne = new TestCategories() { Id = 3, ParentId = 2, OrderInList = 2 };
            var subCategoryTwo = new TestCategories() { Id = 5, ParentId = 1, OrderInList = 3 };
            var subCategoryThree = new TestCategories() { Id = 6, ParentId = 2, OrderInList = 1 };
            var subCategoryFour = new TestCategories() { Id = 7, ParentId = 1, OrderInList = 2 };
            var subCategoryFive = new TestCategories() { Id = 8, ParentId = 4, OrderInList = 1 };

            topCategoryOne.Subcategories.Add(topCategoryThree);
            topCategoryOne.Subcategories.Add(subCategoryTwo);
            topCategoryOne.Subcategories.Add(subCategoryFour);
            topCategoryTwo.Subcategories.Add(subCategoryFive);
            topCategoryThree.Subcategories.Add(subCategoryOne);
            topCategoryThree.Subcategories.Add(subCategoryThree);
            subCategoryOne.Subcategories.Add(topCategoryTwo);

            var listOfCategories = new List<TestCategories>();

            listOfCategories.Add(topCategoryOne);
            listOfCategories.Add(topCategoryTwo);
            listOfCategories.Add(topCategoryThree);
            listOfCategories.Add(subCategoryOne);
            listOfCategories.Add(subCategoryTwo);
            listOfCategories.Add(subCategoryThree);
            listOfCategories.Add(subCategoryFour);
            listOfCategories.Add(subCategoryFive);

           // var myGraph = new IGraph<TestCategories>().ToList();

            foreach (var cat in listOfCategories)
            {
        //       myGraph.Add(cat);
            }
            return null;
        }
    }

}
