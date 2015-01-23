--------------------------------------------------------------------------------
                      Coinding API for Unity - (BETA)                          
--------------------------------------------------------------------------------

# Overview #

Coinding API is a bitcoin service designed to allow developers around the world to easily integrate the power of bitcoin into their games.

We allow multiple interactions with bitcoin through one API including:

- Send tips to game developers or fellow players
- Sending and requesting bitcoin by email or bitcoin address
- Access to raw bitcoin network data
- Fetch random bitcoin information

Some other features we are working on and will be available soon:

- Handle In-App purchases without fees
- Interact with streams and live e-sport matches

We want to help you make great games that work with bitcoin, so please send requests and suggestions to api@coinding.com.

# Quick Start #

  In order to start using Coinding API in your project you need to:
  1. Drag the Coinding prefab from Coinding/Prefab/ to your scene.
  2. That's it! You can now start using Coinding API in your game.

# Examples #  

  1. Get the list of registered developers
    Coinding.i.Developer.GetAll(onSuccess, onError);
    
  2. Get your current developer balance
    Coinding.i.Developer.Balance("some@email.com", "encryptedpass", onSuccess, onError);
    
  3. Register a new player
    Coinding.i.Player.Register("name", "playerpass", onSuccess, onError); 
  
  4. Send a tip to a player
    Coinding.i.Tip.PlayerToPlayer("name", "playerpass", 0.4, "Friendly Player", onSuccess, onError); 
  
  5. Send a tip to a player
    Coinding.i.Tip.PlayerToDeveloper("name", "playerpass", 0.4, "Lucky Developer", onSuccess, onError);
  
  5. Retrieve a random bitcoin transaction
    Coinding.i.Bitcoin.Transaction.Random(onSuccess, onError); 
    
  
# Support #
  
  fpanettieri@gmail.com
  skype: fabio.panettieri


# License #

  Coinding API is provided under The MIT License

# Changelog #

  0.0.1 - Public Beta release
