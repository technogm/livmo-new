import { Router } from "@angular/router";
import { Component, EventEmitter, HostListener, OnInit, Output } from '@angular/core';
import { AuthService } from "../../Services/Auth.service";
import { HostServiceService } from "src/app/Services/host.service";


@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent implements OnInit {

  display: boolean = false;
  shouldAuth: boolean = false;
  photoLink:any;
  a:any

  showMenu = false;
  scrollingTop = false;
  open = false;
  prevScrollPoint = 0;
  mobileNavopen = false
  path = '';
  user:any=localStorage.getItem("ID");
  @Output('routeChange') routeChange: EventEmitter<any> = new EventEmitter();
  constructor(private HostService: HostServiceService,private router:Router) {

    let id =localStorage.getItem("ID");
    console.log("fafaf",id)
    this.HostService.getHostById(id).subscribe(data=>{ //it must be getUserById
      this.a=data;
      
      
      console.log("user",data)
      

      this.photoLink=this.a.photoLink;
 
      console.log("photo",this.photoLink)
      



    })
  
    
  }

  @HostListener('window:scroll', ['$event']) // for window scroll events
  onScroll(event: any) {
    const verticalOffset =
      window.pageYOffset ||
      document.documentElement.scrollTop ||
      document.body.scrollTop ||
      0;

    this.scrollingTop =
      this.prevScrollPoint > verticalOffset || this.prevScrollPoint == 0;
    if (this.open) this.open = false;
    if (this.mobileNavopen) this.mobileNavopen = false;
    this.prevScrollPoint = verticalOffset;
  }
  @HostListener('window:click', ['$event']) // for window scroll events
  blur(event: any) {
    if (this.open && !event.path.find((e: any) => e.localName === 'button'))
      this.open = false;
    if (this.mobileNavopen && !event.path.find((e: any) => e.localName === 'button'))
      this.mobileNavopen = false;
  }
  ngOnInit(): void {
    const paths = ['Angebote','Leistungen','Kontakt']
    this.path = paths.find((p:any) => location.pathname.indexOf(p) !== -1) || ''
  }
  goTo(index: any) {    
    if(this.path === '')
    document
      .getElementById(index)
      ?.scrollIntoView({ behavior: 'smooth', block: 'end', inline: 'nearest' });
    else{
      this.router.navigate([''],{queryParams:{goto:index}}).then(()=>{
        this.routeChange.emit();
        this.ngOnInit()
      })
      
    }
  }
  navigate(path:string){
    this.router.navigate([path]).then(()=>{
      this.routeChange.emit();

      this.ngOnInit()
    })
  }
  showDialog() {
    this.display = true;
  }
  rouuting()
  {
    if (localStorage.getItem("auth-token") === null) {
      this.shouldAuth=true;
    } 
    else if (localStorage.getItem("UserRole")=='Host') 
    {
      this.router.navigate(['/aboutHost']);

    }
    else if (localStorage.getItem("UserRole")=='Commercant') 
    {
      this.router.navigate(['/AboutCommercant']);

    }
    else if (localStorage.getItem("UserRole")=='Client') 
    {
      this.router.navigate(['/AboutClient']);

    }
    else {
      this.router.navigate(['Profil', this.user ]);
    }
  }

  conn = localStorage.getItem("auth-token") === null;

}


