import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree,Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ServicesCommercantService } from '../Services/services-commercant.service';


@Injectable({
  providedIn: 'root'
})
export class CommercantGuard implements CanActivate {
  user:any;
  typeService:any;
  status:any;
  id :any=localStorage.getItem("ID");

  constructor(private router: Router,private CommercantService: ServicesCommercantService) {

  }
//type commercant , valid w type 
// about commercant : depant typeService ( foood, trans,lodging)

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

      if(localStorage.getItem("UserRole") == 'Commercant'){//
        return true;
        console.  log('truuuue')
       
      } else {
        console.log('khnchoufou',this.status)
        this.router.navigate(['/homepage']);
        return false;
      }

        }
  
}
