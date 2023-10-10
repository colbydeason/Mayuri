using Mayuri.Models;
using Mayuri.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mayuri.Commands
{
    public class CreateLogCommand : CommandBase
    {
        public CreateLogCommand(CreateLogViewModel createLogViewModel, ISourceList sources, ILogList logs)
        {
        }

        public override void Execute(object? parameter)
        {
        }
    }
}
