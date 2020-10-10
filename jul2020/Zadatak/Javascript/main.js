import {Match} from "./match.js";
import { Player } from "./player.js";

let mainContainer = document.createElement("div");
mainContainer.classList.add("container");

let player1 = new Player("Novak Djokovic", 33, 1, "E:\GithubRepo\WEBpriprema\jul2020\Zadatak\Javascript\Slike\novak.jpg");
let player2 = new Player("Rafael Nadal", 34, 2, "E:\GithubRepo\WEBpriprema\jul2020\Zadatak\Javascript\Slike\nadal.jpg");
let player3 = new Player("Roger Federer", 38, 4, "E:\GithubRepo\WEBpriprema\jul2020\Zadatak\Javascript\Slike\federer.jpg");

let match1Container = document.createElement("div");
mainContainer.appendChild(match1Container);


