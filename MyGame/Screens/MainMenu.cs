#pragma warning disable CA1416

namespace MyGame
{
    class MainMenu
    {
        public static GameState GetInput()
        {
            Draw();

            Console.CursorVisible = true;
            Console.SetCursorPosition(66, 14);

            var key = Console.ReadKey(true).Key;

            while (key != ConsoleKey.D1 && key != ConsoleKey.D2)
                key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
                return GameState.Start;

            else return GameState.Quit;
        }

        public static void Draw()
        {
            Console.Clear();
            Console.SetWindowSize(113, 46);
            Console.SetBufferSize(113, 46);

            Console.WriteLine(@"                                                                    
                 oddl                                                              oddl               
                dWMMO                                                     cxO     lNWWx               
                0MMWl                                                    KWMO                         
               lWMM0    cxxo  lxO0Ox        lxO00Oxl        lxxloodO0 dxKMMMXkl   dxxc      dkO00Oko  
               OMMMd    XMMWX0kdONMMNl    xNMW0xkKWMNl     cNMMXKNXXO OXWMMWK0o  xMMWl   cKWWXkdxKMMNl
               NMMX    dMMMXo    kMMWo   KMMKc    kMMX     kMMMNx      dWMMk     KMM0            cNMMk
              xMMMk    KMMXc     KMMX   kMMM0lllclOMMWl    XMMXc       OMMNc    oWMMd      loddxkXMMWo
              KMMNc   oWMMx     lWMMx   KMMWK00000000O    dMMWd        XMMO     0MMX    kNMWKkdokNMMK 
             oWMMO    OMMX      OMMN    OMMX             d0MMK        xWMWo    cNMMk   kMMXc    dWMMx 
             OMMWo    NMMO      NMMO     XMWKo  l0WNk   lNWMMx        0MMWkc   kMMNc   kMMNx  lONMMNc 
             XNN0    dNNNl     dNNNl      dKNMMMWN0o    kWNNX         oXWMMMk  KNNO     kXWMWN0x0NNX   


                                                Choose an option:

                                                  1. Start Game
                                                    2. Quit
                                                            
                                 
                                                 xxddxxk                                              
                                               ;dxxddxxkxo;         ,,,,                              
                                               lkdodkdoxkkd      ,,,,,,                               
                                               :xxdxkdxxkko,  ,,,,                                    
                                                 lkkkkxlcc:,,,                                        
                                             ,cdkdc::;,,;;:c;                                         
                                           :kKXKKK0kdddxkO0KOl                                        
                                          lKXK00KKKXXXXKKKKKKK0xo,                                    
                                          OXXk,cKXKKKKKKXXKkkKXXXx;                                   
                                         ;0XXd :KXKXKKK0Okx:;cloo;                                    
                                         ,kxdc :0KOkxdolcccccc:           oxk0x                       
                                          kxd    ,:ccccc; ,;:cc:,;cllodddkKNNNk                       
                                                   ,:ccc;  :lccclxxdolloooxKNNk                       
                                                    :cccokO0xlccccllooooold0NNk                       
                                                 colccccoddool:;:c::loodkOKXNNk                       
                                             dx0KKkl:ccclooooolc::cokOKXNNNNNNk                       
                                         dx0K0Oxdoc;;cc:cllllodxk0KXNNNNNNNNNNk                       
                                     dx0X0kxdolooolc::;;cldkO0XNNNNNNNNNNNNNNNk                       
                                   dXNNNOoloooooooooodxO0KXNNNNNNNNNNNNNNNNNNNk                       
                                   dNNNNKdoooloodxk0KXNNNNNNNNNNNNNNNNNNNNNNNNk                       
                                    dNNNNKkdxkO0XNNNNNNNNNNNNNNNNNNNNNNNNNNNNK                       
                                     dKXNNXKXNNNNNNNNNNNNNNNNNNNNNNNNNNNNNXXk                        
            ");
        }
    }
}
