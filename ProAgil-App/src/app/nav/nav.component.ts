import { AuthService } from 'src/app/_services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(
    public router: Router,
    private toastr: ToastrService,
    public authService: AuthService
  ) {}

  ngOnInit() {
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  entrar() {
    this.router.navigate(['/user/login']);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
}
