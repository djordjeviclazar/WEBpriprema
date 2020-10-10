import { Result } from "./result";

export class Match
{
    constructor(container, player1, player2, time, date)
    {
        this.container = container;
        this.player1 = player1;
        this.player2 = player2;
        this.time = time;
        this.date = date;
        this.result = null;
        this.draw();
    }

    draw()
    {

    }
}