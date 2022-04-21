#pragma warning disable CA1416

namespace MyGame
{
    class GameOverScreen
    {
        public static GameState GetInput()
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(78, 12);

            var key = Console.ReadKey(true).Key;

            while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3)
                key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
                return GameState.Retry;

            else if (key == ConsoleKey.D2)
                return GameState.CreateNew;

            else return GameState.Quit;
        }

        public static void Show()
        {
            Console.Clear();
            Console.SetWindowSize(133, 42);
            Console.SetBufferSize(133, 42);
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(@"                                                                    
                                                                                                                          
                 d0XXXNX0o                                                                                                
               kWXxc   oKMK                                                                                               
              0MK             x000KKk    kKOxkKX0olxOKKx    d000KKOd          ck000K0d   lKk     k0o   k000KOc   c00xxKO 
             dMNc    ooooo         oNMk  oWWO  oNMXo  OMX  cXWk  cKMMO        OWXl   0M0  cNWl   KWx  xWXl  xWNl  OMWOc   
             kMX    lxxKWWx   ldxxx0WWo  0M0   oWWo   KMO  0MW0xxOXWMK       oWNl    xMX   OMx cXNo  lWMXclc0WWd  NWk     
             oWNo      kMX   XWO   KM0  cNWo   0M0   oWWl  KMKl              dMNc    KMO   oWX0NXc   oWWk        xMX      
              dNW0xdxOXWNd  cNWOllOWMx  kMK   cNWd   0M0   cXNkllkK0d         0WKocxXNk     KMW0      kNKdcd00c  XMk      
                cddxdol       oxdxdlo   co     ol    lo      cdxdo              odxdl        ol         ldxdl    lo   

            ");

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(@"
                                                            Choose an option:

                                                        1. Restart current level
                                                           2. Create new level
                                                                3. Quit         
                                                            
                                 
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
