export class Set
{
    constructor()
    {
        this.isEnded = false;
        this.player2Gems = 0;
        this.player1Gems = 0;
    }

    playerScored(isPlayer1)
    {
        if (isPlayer1 == null) {return null;}

        if (isPlayer1)
        {
            this.player1Gems++;
            if (this.player1Gems == 6) 
            {
                this.isEnded = true;
            }
        }
        else 
        {
            this.player2Gems++;
            if (this.player2Gems == 6) 
            {
                this.isEnded = true;
            }
        }

        return this.isEnded;
    }
}