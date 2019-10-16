using dappertutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dappertutorial.DAL
{
    public interface IUpdateTodoItem
    {
        Task<int> UpdateTodoItem(TodoItem todoItem, int id);
    }
}
