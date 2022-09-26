import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { DataFlight } from 'src/app/model/dataFllight.model';
import { Flight } from 'src/app/model/flight.model';
import { Journey } from 'src/app/model/journey.model';
import { FlightService } from 'src/app/service/flight.service';
import Swal from 'sweetalert2';
declare const $: any;
@Component({
  selector: 'app-viajes',
  templateUrl: './viajes.component.html',
  styleUrls: ['./viajes.component.css']
})



export class ViajesComponent implements OnInit,AfterViewInit {

  constructor(private serviceVuelos:FlightService,private spinner:NgxSpinnerService,private fb:FormBuilder,private router:Router) { }
  tabla:any;
  listOrigen :string[]=[];
  listDestination:string[]=[];
  listMonedas:string[]=[];
  dataFlight:DataFlight[]=[];
  formViaje:FormGroup;
  precios:number[]=[];
  ngOnInit(): void {
    this.listMonedas.push("USD");
    this.listMonedas.push("CO");
    this.listMonedas.push("EUR");
    this.formViaje = this.fb.group({
      sorigen:[''],
      sdestination:[''],
      smoneda:['']
    });

    this.formViaje.get('smoneda').setValue('USD');

    this.spinner.show(undefined, { fullScreen: true });

    this.serviceVuelos.getAll().subscribe({
      next:(resp:Flight[])=>{
        this.spinner.hide();

        resp.forEach(x=> {
          if (this.listOrigen.find(y=>y==x.origin)==undefined) {
            this.listOrigen.push(x.origin);
          };
          if (this.listDestination.find(y=>y==x.destination)==undefined) {
            this.listDestination.push(x.destination);
          }
        })
                         
      },
      error:(error:any)=>{
        this.spinner.hide();
        Swal.fire("Error",error.error.Message,'error');
      }
    })
  }

    //Muestra la tabla con los productos
    ngAfterViewInit(): void {

      
      setTimeout(()=>{        
        this.tabla= $('#datatables').DataTable({
          pagingType: "full_numbers",
          lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, "Todos"]
          ],
          data:[],
          dom: '<"top"f>rt<"bottom"lp><"clear">',
          columnDefs: [
            {
                targets: 0,
                className: 'dt-body-left'
            },
            {
              targets: 1,
              className: 'dt-body-left'
            },
            {
              targets: 2,
              className: 'dt-body-left'
            },
            {
              targets: 3,
              className: 'dt-body-left'
            },
            {
              targets: 4,
              className: 'dt-body-right'
            }
          ],
          columns:[                
                   {title:'Origen',data:'origin',width:'15%'},
                   {title:'Destino',data:'destination',width:'15%'},
                   {title:'Vuelo',data:'flightCarrier',width:'15%'},
                   {title:'Número',data:'flightNumber',width:'15%'},
                   {title:'Precio',data:'price',width:'15%',  render: (item,data,key)=> {
                      return `${item} ${this.formViaje.get('smoneda').value}`;
                    }}],
          paging: true,
          language: {
          search: "_INPUT_",
          searchPlaceholder: "Buscar",
          lengthMenu: "Mostar _MENU_ registros por página",
          zeroRecords: "No hay datos",
          info: "Mostrando _PAGE_ de _PAGES_",
          infoEmpty: "Mostrando 0 a 0 de 0 registros",
          infoFiltered: "(filtered from _MAX_ total registros)",
          paginate: {
            first:      "Primero",
            last:       "Último",
            next:       "Próximo",
            previous:   "Anterior"
          },
        }     
  
        });      
      });  
    }

    onClicBuscar() {
     
    }

    onSubmit() {
      console.log("Origen",this.formViaje.get('sorigen').value);
      console.log("Destination",this.formViaje.get('sdestination').value);
      this.dataFlight=[];
      let viaje:Flight = new Flight();
      viaje.origin = this.formViaje.get('sorigen').value;
      viaje.destination=this.formViaje.get('sdestination').value;
      this.spinner.show(undefined, { fullScreen: true });
      this.serviceVuelos.get(viaje).subscribe({
        next:(resp:Journey) =>{
          this.spinner.hide();
          resp.flights.forEach(x=>{
            this.dataFlight.push({
              origin:x.origin,
              destination:x.destination,
              flightCarrier:x.transport.flightCarrier,
              flightNumber:x.transport.flightNumber,
              price:x.price
            });            
          });

          this.dataFlight.forEach(x=>{
            this.precios.push(x.price);
          })
          
          $('#datatables').DataTable().clear();          
          $('#datatables').DataTable().rows.add(this.dataFlight);
          $('#datatables').DataTable().draw();
          console.log("Datos",this.dataFlight);
        },
        error:(err:any) =>{
          Swal.fire("Error","Error al traer los datos","error");
          this.spinner.hide();
        }
      });
    }

    onSalir() {
      localStorage.removeItem("login");
      this.router.navigateByUrl('/login');
      
    }
    onChangeMoneda() {

    }
}
