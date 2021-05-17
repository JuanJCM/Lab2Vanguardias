import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact-title',
  templateUrl: './contact-title.component.html',
  styleUrls: ['./contact-title.component.css']
})
export class ContactTitleComponent implements OnInit {
  title: string = "Lista de Contactos";
  constructor() { }

  ngOnInit(): void {
  }

}
