using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UStore.Domain.Repositories
{
    //interfaces contain definitions for props and functionality (methods) that a class or struct can implement.
    //By using interfaces we can combine otherwise unrelated classes into a single collection.
    //Naming Convention: 'I'DoSomething'able'

    public interface IGenericRepositable
    {
        //any class (GenericRepo) that wants to use this set of rules must implement the interface at the class level and satisfy the reqs in the body of the class. 
        //we inherit from other classes, but implement interface(s)
        //we can implement multiple interfaces simultaneously

    }
}
