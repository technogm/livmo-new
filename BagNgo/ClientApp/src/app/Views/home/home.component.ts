import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() {
    const isPhone = window.innerWidth < 500;
   }
  themes = [{
    id: 1,
    title: 'Culture',
    image: 'assets/img/Culture.png'
  },
  {
    id: 2,

    title: 'Event',
    image: 'assets/img/Event.png'
  },
  {
    id: 3,

    title: 'Health',
    image: 'assets/img/Health.png'
  },
  {
    id: 4,

    title: 'Seaside',
    image: 'assets/img/Seaside.png'
  },
  {
    id: 5,

    title: 'Food',
    image: 'assets/img/food.jpg'
  },
  {
    id: 6,

    title: 'Nature',
    image: 'assets/img/nature.jpg'
  },
]
  ngOnInit(): void {
  }

}
