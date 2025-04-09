using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TODOLIST.Models;

namespace TODOLIST.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _newTodo;
        public string NewTodo
        {
            get => _newTodo;
            set
            {
                _newTodo = value;
                OnPropertyChanged();
                // AddCommand 버튼의 활성화 상태를 다시 체크
                (AddCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<TodoItem> TodoList { get; set; }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }

        public MainViewModel()
        {
            TodoList = new ObservableCollection<TodoItem>();
            AddCommand = new RelayCommand(AddTodo, () => !string.IsNullOrWhiteSpace(NewTodo));
            RemoveCommand = new RelayCommand<TodoItem>(RemoveTodo);
        }

        private void AddTodo()
        {
            TodoList.Add(new TodoItem { Content = NewTodo });
            NewTodo = string.Empty;
        }

        private void RemoveTodo(TodoItem item)
        {
            if (TodoList.Contains(item))
                TodoList.Remove(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
