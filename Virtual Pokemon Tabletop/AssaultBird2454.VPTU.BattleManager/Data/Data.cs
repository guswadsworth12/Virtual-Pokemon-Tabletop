using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssaultBird2454.VPTU.BattleManager.Data
{
    /// <summary>
    /// Defines Pokemon & Move Types
    /// </summary>
    public enum Type { Normal = 1, Fire, Fighting, Water, Flying, Grass, Poison, Electric, Ground, Psychic, Rock, Ice, Bug, Dragon, Ghost, Dark, Steel, Fairy }
    /// <summary>
    /// Defines Move Classes
    /// </summary>
    public enum MoveClass { Status, Physical, Special, Static }
    public enum Action_Type { Standard_Action, Shift_Action, Swift_Action, Free_Action, Extended_Action, Full_Action, F_Priority_Action, L_Priority_Action, Interrupt_Action }
}
