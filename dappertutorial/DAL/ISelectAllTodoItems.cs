using dappertutorial.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dappertutorial.DAL
{
    public interface ISelectAllTodoItems
    {
        Task<IEnumerable<TodoItemDAL>> SelectAllTodoItems();
    }
}
