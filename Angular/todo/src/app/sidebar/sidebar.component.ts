import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  data = 'Sidebar Data';
  estaSeleccionado = true;

  currentClasses = {
    star: true,
    active: false,
    other: true
  };

  constructor() { }

  ngOnInit(): void {
  }


  public checkboxChanged() {

  }

}
