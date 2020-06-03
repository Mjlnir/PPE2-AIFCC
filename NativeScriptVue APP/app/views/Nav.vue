<template>
    <GridLayout rows="auto" columns="*, *, *">
        <Button text='Reserver' @tap="goTo('cal')" row="1" col="0" />
        <Button text='Utilisateurs' @tap="goTo('user')" row="1" col="1" />
        <Button text='Véhicules' @tap="goTo('veh')" row="1" col="2" />
    </GridLayout>
</template>

<script>
    import Reserve from "./Reserve";
    import Users from "./Users";
    import Vehicles from "./Vehicles";

    export default {
        data() {
            return {
                routes: {
                    cal: Reserve,
                    user: Users,
                    veh: Vehicles
                }
            };
        },
        methods: {
            goTo(s) {
                this.$navigateTo(this.routes[s]);
            }
        }
    };
</script>

<style>
</style>