using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dappertutorial.DAL
{
    public interface IDeleteTodoItem
    {
        Task<int> DeleteTodoItem(int id);
    }
}
