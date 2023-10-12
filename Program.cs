List<string> TaskList = new List<string>();

            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        
        /// <summary>
        /// Show the options for Task, 1. Nueva Tarea
        /// </summary>
        /// <returns>Returns option selected by user</returns>
        int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                
                ShowMenuTaskList();

                string line = Console.ReadLine();
                // Remove one position bacause the array starts in 0
                int indexToRemove = Convert.ToInt32(line) - 1;

                if(indexToRemove > (TaskList.Count -1) || indexToRemove <-0)
                    Console.WriteLine("Numero de tarea seleccionado no es valido");
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                    
                        string taskRemoved = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + taskRemoved + " eliminada");
                
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskRegistered = Console.ReadLine();
                TaskList.Add(taskRegistered);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                 Console.WriteLine("----------------------------------------");
                var indexTask=1;
                TaskList.ForEach(p=> Console.WriteLine($"{indexTask++} . {p}"));

                Console.WriteLine("----------------------------------------");

               
            } 
            else
            {
                 Console.WriteLine("No hay tareas por realizar");
            }
        }

    public enum Menu
    {
        Add = 1,

        Remove = 2,

        List = 3,

        Exit = 4
    }

