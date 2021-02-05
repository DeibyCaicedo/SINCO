
import React, { useState, useEffect } from 'react';

import { forwardRef } from 'react';
import Grid from '@material-ui/core/Grid'

import MaterialTable from "material-table";
import AddBox from '@material-ui/icons/AddBox';
import ArrowDownward from '@material-ui/icons/ArrowDownward';
import Check from '@material-ui/icons/Check';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import DeleteOutline from '@material-ui/icons/DeleteOutline';
import Edit from '@material-ui/icons/Edit';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Remove from '@material-ui/icons/Remove';
import SaveAlt from '@material-ui/icons/SaveAlt';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';
import axios from 'axios'
import Alert from '@material-ui/lab/Alert';

const tableIcons = {
  Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
  Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
  Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  Delete: forwardRef((props, ref) => <DeleteOutline {...props} ref={ref} />),
  DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
  Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
  Export: forwardRef((props, ref) => <SaveAlt {...props} ref={ref} />),
  Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
  FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
  LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
  NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
  PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
  ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
  SortArrow: forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
  ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
  ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)
};

const api = axios.create({
  baseURL: 'https://localhost:44326/api'
})



function App() {

  var columns = [
    {title: "id", field: "id", hidden: true},
    {title: "identificación", field: "identificación"},
    {title: "nombre", field: "nombre"},
    {title: "apellido", field: "apellido"},
    {title: "edad", field: "edad" , type:"numeric"},
    {title: "dirección", field: "dirección"},
    {title: "telefono", field: "telefono"}

  ]
  var columnsp = [
    {title: "id", field: "id", hidden: true},
    {title: "identificación", field: "identificación"},
    {title: "nombre", field: "nombre"},
    {title: "apellido", field: "apellido"},
    {title: "edad", field: "edad" , type:"numeric"},
    {title: "dirección", field: "dirección"},
    {title: "telefono", field: "telefono"},
    {title: "asignaturaid", field: "asignaturaid", type:"numeric"}

  ]
  var columnsa = [
    {title: "id", field: "id", hidden: true},
    {title: "nombre", field: "nombre"}

  ]
  const [data, setData] = useState([]); //table data
  const [datap, setDatap] = useState([]); //table data
  const [dataa, setDataa] = useState([]); //table data



  //for error handling
  const [iserror, setIserror] = useState(false)
  const [errorMessages, setErrorMessages] = useState([])

  useEffect(() => { 
    api.get("/alumno")
        .then(res => {               
            setData(res.data)
         })
         .catch(error=>{
             console.log("Error")
         })
  }, [])

  const handleRowUpdate = (newData, oldData, resolve, apicons) => {
    //validation
    let errorList = []
    if(apicons == "/asignatura"){    
      if(newData.nombre === ""){
        errorList.push("Por favor ingrese nombre")
      }
    }else{
      if(newData.identificación === ""){
        errorList.push("Por favor ingrese la identificación")
      }
      if(newData.nombre === ""){
        errorList.push("Por favor ingrese nombre")
      }
      if(newData.apellido === ""){
        errorList.push("Por favor ingrese apellido")
      }
      if(newData.edad === ""){
        errorList.push("Por favor ingrese edad")
      }
      if(newData.dirección === ""){
        errorList.push("Por favor ingrese dirección")
      }
      if(newData.telefono === ""){
        errorList.push("Por favor ingrese telefono")
      }
    }

    if(errorList.length < 1){
      api.put(apicons+newData.id, newData)
      .then(res => {
        const dataUpdate = [...data];
        const index = oldData.tableData.id;
        dataUpdate[index] = newData;
        setData([...dataUpdate]);
        resolve()
        setIserror(false)
        setErrorMessages([])
      })
      .catch(error => {
        setErrorMessages(["No se pudo editar el registro"])
        setIserror(true)
        resolve()
        
      })
    }else{
      setErrorMessages(errorList)
      setIserror(true)
      resolve()

    }
    
  }

  const handleRowAdd = (newData, resolve,apicons) => {
    //validation
    let errorList = []
    if(apicons == "/asignatura"){    
      if(newData.nombre === undefined){
        errorList.push("Por favor ingrese nombre")
      }
    }else{
      if(newData.identificación === undefined){
        errorList.push("Por favor ingrese la identificación")
      }
      if(newData.nombre === undefined){
        errorList.push("Por favor ingrese nombre")
      }
      if(newData.apellido === undefined){
        errorList.push("Por favor ingrese apellido")
      }
      if(newData.edad === undefined){
        errorList.push("Por favor ingrese edad")
      }
      if(newData.dirección === undefined){
        errorList.push("Por favor ingrese dirección")
      }
      if(newData.telefono === undefined){
        errorList.push("Por favor ingrese telefono")
      }
    }

    if(errorList.length < 1){ //no error
      api.post(apicons, newData)
      .then(res => {
        let dataToAdd = [...data ];
        dataToAdd.push(newData);
        setData(dataToAdd);
        resolve()
        setErrorMessages([])
        setIserror(false)
      })
      .catch(error => {
        setErrorMessages(["No se pudo agregar el registro. Server error!"])
        setIserror(true)
        resolve()
      })
    }else{
      setErrorMessages(errorList)
      setIserror(true)
      resolve()
    }

    
  }

  const handleRowDelete = (oldData, resolve, apicons) => {
    
    api.delete(apicons+oldData.id)
      .then(res => {
        const dataDelete = [...data];
        const index = oldData.tableData.id;
        dataDelete.splice(index, 1);
        setData([...dataDelete]);
        resolve()
      })
      .catch(error => {
        setErrorMessages(["No se pudo eliminar el registro"])
        setIserror(true)
        resolve()
      })
  }

  useEffect(() => { 
    api.get("/profesor")
        .then(res => {               
            setDatap(res.data)
         })
         .catch(error=>{
             console.log("Error")
         })
  }, [])

  useEffect(() => { 
    api.get("/asignatura")
        .then(res => {               
            setDataa(res.data)
         })
         .catch(error=>{
             console.log("Error")
         })
  }, [])
  return (
    <div className="App">
      
      <Grid container spacing={1}>
          <Grid item xs={3}></Grid>
          <Grid item xs={6}>
          <div>
            {iserror && 
              <Alert severity="error">
                  {errorMessages.map((msg, i) => {
                      return <div key={i}>{msg}</div>
                  })}
              </Alert>
            }       
          </div>
            <MaterialTable
              title="Información de alumnos "
              columns={columns}
              data={data}
              icons={tableIcons}
              editable={{
                onRowUpdate: (newData, oldData) =>
                  new Promise((resolve) => {
                      handleRowUpdate(newData, oldData, resolve,"/alumno/");
                      
                  }),
                onRowAdd: (newData) =>
                  new Promise((resolve) => {
                    handleRowAdd(newData, resolve, "/alumno")
                  }),
                onRowDelete: (oldData) =>
                  new Promise((resolve) => {
                    handleRowDelete(oldData, resolve, "/alumno/")
                  }),
              }}
            />
          </Grid>
          <Grid item xs={3}></Grid>
        </Grid>
        <Grid container spacing={1}>
          <Grid item xs={2}></Grid>
          <Grid item xs={8}>
          <div>
            {iserror && 
              <Alert severity="error">
                  {errorMessages.map((msg, i) => {
                      return <div key={i}>{msg}</div>
                  })}
              </Alert>
            }       
          </div>
            <MaterialTable
              title="Información de profesores "
              columns={columnsp}
              data={datap}
              icons={tableIcons}
              editable={{
                onRowUpdate: (newData, oldData) =>
                  new Promise((resolve) => {
                      handleRowUpdate(newData, oldData, resolve,"/profesor/");
                      
                  }),
                onRowAdd: (newData) =>
                  new Promise((resolve) => {
                    handleRowAdd(newData, resolve,"/profesor")
                  }),
                onRowDelete: (oldData) =>
                  new Promise((resolve) => {
                    handleRowDelete(oldData, resolve,"/profesor/")
                  }),
              }}
            />
          </Grid>
          <Grid item xs={2}></Grid>
        </Grid>

        <Grid container spacing={1}>
          <Grid item xs={3}></Grid>
          <Grid item xs={5}>
          <div>
            {iserror && 
              <Alert severity="error">
                  {errorMessages.map((msg, i) => {
                      return <div key={i}>{msg}</div>
                  })}
              </Alert>
            }       
          </div>
            <MaterialTable
              title="Información de asignaturas "
              columns={columnsa}
              data={dataa}
              icons={tableIcons}
              editable={{
                onRowUpdate: (newData, oldData) =>
                  new Promise((resolve) => {
                      handleRowUpdate(newData, oldData, resolve,"/asignatura/");
                      
                  }),
                onRowAdd: (newData) =>
                  new Promise((resolve) => {
                    handleRowAdd(newData, resolve,"/asignatura")
                  }),
                onRowDelete: (oldData) =>
                  new Promise((resolve) => {
                    handleRowDelete(oldData, resolve,"/asignatura/")
                  }),
              }}
            />
          </Grid>
          <Grid item xs={3}></Grid>
        </Grid>
    </div>
    
  );
}

export default App