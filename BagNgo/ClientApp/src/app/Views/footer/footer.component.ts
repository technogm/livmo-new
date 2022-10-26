import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  PreventedRoutes :any = ["addHost","addCommercant","LoginUsers","AddExperience","addClient","AddDish","AddTransport","AddLodging","emailconfirmation"]
  constructor(private router: Router) {
    router.events.subscribe((val) => this.PreventedRoutes.forEach(route => {   
      if(location.pathname.includes(route))
      this.showFooter = false
    }));
    }  
    showFooter :any = true

  ngOnInit(): void {
    this.PreventedRoutes.forEach(route => {   
      if(location.pathname.includes(route))
      this.showFooter = false
    });
  }
}
